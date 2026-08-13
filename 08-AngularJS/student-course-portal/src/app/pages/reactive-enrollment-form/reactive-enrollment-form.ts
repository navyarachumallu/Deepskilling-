import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
  FormArray,
  FormControl
} from '@angular/forms';

import { CourseService } from '../../services/course';
import { Course } from '../../models/course.model';

import { noCourseCode } from '../../validators/no-course-code.validator';
import { simulateEmailCheck } from '../../validators/email.validator';

@Component({
  selector: 'app-reactive-enrollment-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './reactive-enrollment-form.html',
  styleUrl: './reactive-enrollment-form.css'
})
export class ReactiveEnrollmentForm implements OnInit {

  enrollForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private courseService: CourseService
  ) {}

  ngOnInit(): void {

    this.enrollForm = this.fb.group({

      studentName: [
        '',
        [
          Validators.required,
          Validators.minLength(3)
        ]
      ],

      studentEmail: this.fb.control(
        '',
        [
          Validators.required,
          Validators.email
        ],
        [
          simulateEmailCheck
        ]
      ),

      courseId: [
        '',
        [
          Validators.required,
          noCourseCode
        ]
      ],

      preferredSemester: [
        'Odd',
        Validators.required
      ],

      agreeToTerms: [
        false,
        Validators.requiredTrue
      ],

      additionalCourses: this.fb.array([])

    });

  }

  get additionalCourses(): FormArray<FormControl> {
    return this.enrollForm.get('additionalCourses') as FormArray<FormControl>;
  }

  addCourse(): void {
    this.additionalCourses.push(
      new FormControl('', Validators.required)
    );
  }

  removeCourse(index: number): void {
    this.additionalCourses.removeAt(index);
  }

  onSubmit(): void {

    if (this.enrollForm.invalid) {
      this.enrollForm.markAllAsTouched();
      return;
    }

    const formValue = this.enrollForm.value;

    const newCourse: Omit<Course, 'id'> = {
      name: formValue.studentName,
      code: formValue.courseId,
      credits: 4,
      gradeStatus: 'pending'
    };

    this.courseService.createCourse(newCourse).subscribe({
      next: (course) => {
        console.log('Course Created:', course);
        alert('Course added successfully!');
        this.enrollForm.reset();

        this.enrollForm.patchValue({
          preferredSemester: 'Odd',
          agreeToTerms: false
        });

        while (this.additionalCourses.length) {
          this.additionalCourses.removeAt(0);
        }
      },
      error: (err) => {
        console.error(err);
        alert('Failed to add course.');
      }
    });

  }

}