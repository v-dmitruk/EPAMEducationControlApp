import { Component, OnInit } from '@angular/core';
import { TeacherService } from '../shared/teacher.service';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent implements OnInit {

  constructor(private teacherService : TeacherService) {  }

  ngOnInit() {
    this.teacherService.getTeacherList();
  }

}
