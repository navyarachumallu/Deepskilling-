import { AbstractControl, ValidationErrors } from '@angular/forms';

export function noAdminName(
  control: AbstractControl
): ValidationErrors | null {

  const value = control.value;

  if (!value) {
    return null;
  }

  if (value.toLowerCase() === 'admin') {
    return { adminName: true };
  }

  return null;
}