import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { CourseService } from '../../services/course';
import { Course } from '../../models/course.model';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList implements OnInit {

  courses: Course[] = [];
  searchTerm = '';

  isLoading = true;
  errorMessage = '';

  constructor(
    private courseService: CourseService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    console.log('CourseList instance created');
  }

  ngOnInit(): void {

    console.log('ngOnInit called');

    this.searchTerm =
      this.route.snapshot.queryParamMap.get('search') ?? '';

    this.courseService.getCourses().subscribe({
      next: (courses) => {
        console.log('API Courses:', courses);

        this.courses = courses;

        console.log('this.courses:', this.courses);
        console.log('Length:', this.courses.length);
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = err.message;
      },
      complete: () => {
        this.isLoading = false;
      }
    });

  }

  goToCourse(id: number): void {
    this.router.navigate(['courses', id]);
  }

  searchCourses(): void {
    this.router.navigate(
      ['courses'],
      {
        queryParams: {
          search: this.searchTerm
        }
      }
    );
  }

}