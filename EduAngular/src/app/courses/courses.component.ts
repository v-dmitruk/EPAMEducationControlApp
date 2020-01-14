import { Component, OnInit } from '@angular/core';
import { CourseService } from '../shared/course.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  constructor(private courseService : CourseService) {  }

  ngOnInit() {
    this.courseService.getAllCourseList();
  }



}
