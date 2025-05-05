import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { RegistrationApiService } from '../../services/registration-api.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register',
  standalone: false,
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css',
})
export class RegistrationComponent implements OnInit {
  step = 1;
  registerFormStep1!: FormGroup;
  registerFormStep2!: FormGroup;

  countries$!: Observable<any[]>;
  provinces$!: Observable<any[]>;

  error: string | null = null;
  success: string | null = null;

  constructor(private fb: FormBuilder, private api: RegistrationApiService) { }

  ngOnInit(): void {
    this.countries$ = this.api.getCountries();

    this.provinces$ = new Observable();
    this.registerFormStep1 = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [
        Validators.required,
        Validators.pattern('^(?=.*[A-Z])(?=.*\\d).+$')
      ]],
      confirmPassword: ['', Validators.required],
      agree: [false, Validators.requiredTrue]
    }, { validators: this.passwordMatchValidator });

    this.registerFormStep2 = this.fb.group({
      countryId: [null, Validators.required],
      provinceId: [null, Validators.required]
    });

    this.registerFormStep2.get('countryId')?.valueChanges.subscribe(id => {
      if (id) {
        this.provinces$ = this.api.getProvinces(id);
        this.registerFormStep2.get('provinceId')?.reset();
      }
    });
  }

  passwordMatchValidator(group: FormGroup) {
    const pass = group.get('password')?.value;
    const confirm = group.get('confirmPassword')?.value;
    return pass === confirm ? null : { mismatch: true };
  }

  nextStep() {
    if (this.registerFormStep1.valid) {
      this.step = 2;
    } else {
      this.registerFormStep1.markAllAsTouched();
    }
  }

  save() {
    if (this.registerFormStep2.valid) {
      const user = {
        email: this.registerFormStep1.value.email,
        password: this.registerFormStep1.value.password,
        confirmationGiven: this.registerFormStep1.value.agree,
        countryId: this.registerFormStep2.value.countryId,
        provinceId: this.registerFormStep2.value.provinceId
      };

      this.api.registerUser(user).subscribe({
        next: () => {
          this.success = 'User registered successfully!';
        },
        error: (error: HttpErrorResponse) => {
          if (error.status === 400) {
            if (typeof error.error === 'string') {
              this.error = error.error ;
            } else if (Array.isArray(error.error)) {
              const messages = error.error.map((e: any) => e.errorMessage || e.ErrorMessage).join('\n');
              this.error = messages;
            } else {
              this.error = 'Undefined error';
              console.error(error.error);
            }
          } else {
            this.error = 'Server error: ' + error.message;
          }
        }
      });
    } else {
      this.registerFormStep2.markAllAsTouched();
    }
  }
}
