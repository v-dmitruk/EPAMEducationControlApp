import { Injectable } from '@angular/core';
import { Student } from './student.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  readonly rootUrl = 'http://localhost:52059/';
  allStudentList : Student[];

  constructor(private http : HttpClient) { }

  getStudentList() {
    this.http.get(this.rootUrl+'api/Students')
    .map((data : any) =>{
      return data as Student[];
    }).toPromise().then(x => {
      this.allStudentList = x;
    })
  }
}
