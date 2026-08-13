import { Routes } from '@angular/router';

import { EnrollmentForm } from '../../pages/enrollment-form/enrollment-form';
import { ReactiveEnrollmentForm } from '../../pages/reactive-enrollment-form/reactive-enrollment-form';

export const ENROLLMENT_ROUTES: Routes = [
  {
    path: '',
    component: EnrollmentForm
  },
  {
    path: 'reactive',
    component: ReactiveEnrollmentForm
  }
];