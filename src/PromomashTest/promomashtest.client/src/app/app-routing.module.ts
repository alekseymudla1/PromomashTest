import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MainComponent } from './components/main/main.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { StepFirstComponent } from './components/step-first/step-first.component';
import { StepSecondComponent } from './components/step-second/step-second.component';

const routes: Routes = [
  { path: '', component: MainComponent },
  {
    path: 'registration',
    component: RegistrationComponent,
    children: [
      { path: 'step1', component: StepFirstComponent },
      { path: 'step2', component: StepSecondComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
