import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { CourseService } from '../shared/course.service';
import { ToastrService } from 'ngx-toastr';
import { Course } from '../shared/course.model';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css'],
  providers: [CourseService]
})
export class StartComponent implements OnInit {
  userClaims : any;

  constructor(private userService: UserService, private courseService : CourseService, private toastr : ToastrService) {  }

  ngOnInit() {
    this.courseService.getActiveCourseList();
  }

}
