import { Component, OnInit } from '@angular/core';
import { StudentService } from '../shared/student.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  constructor(private studentService : StudentService) {  }

  ngOnInit() {
    this.studentService.getStudentList();
  }

}
