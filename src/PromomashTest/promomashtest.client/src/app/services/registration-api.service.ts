import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { CreateUserRequest } from '../components/CreateUserRequest';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RegistrationApiService {
  private readonly baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }

  getCountries(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/locations/countries`);
  }

  getProvinces(countryId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/locations/countries/${countryId}/provinces`);
  }

  registerUser(payload: CreateUserRequest): Observable<any> {
    return this.http.post(`${this.baseUrl}/users`, payload).pipe(
      catchError((error) => {
        console.error('Error during POST /users', error);
        return throwError(() => error);
      })
    );
  }
}
