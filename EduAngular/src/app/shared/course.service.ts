import { Injectable } from '@angular/core';
import { Course } from './course.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  readonly rootUrl = 'http://localhost:52059/';
  selectedCourse : Course;
  guestCourseList : Course[];
  allCourseList : Course[];
  userCourseList : Course[];
  searchedCourseList : Course[];

  constructor(private http : HttpClient) { }

  getActiveCourseList() {
    var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
    this.http.get(this.rootUrl+'api/GetActiveCourses', { headers: reqHeader })
    .map((data : any) =>{
      return data as Course[];
    }).toPromise().then(x => {
      this.guestCourseList = x;
    })
  }

  getUserCourseList(id) {
    this.http.get(this.rootUrl+'api/GetActiveCourses')
    .map((data : any) =>{
      return data as Course[];
    }).toPromise().then(x => {
      this.guestCourseList = x;
    })
  }

  getAllCourseList() {
    this.http.get(this.rootUrl+'api/Courses')
    .map((data : any) =>{
      return data as Course[];
    }).toPromise().then(x => {
      this.allCourseList = x;
    })
  }

  // postEmployee(emp : Employee){
  //   var body = JSON.stringify(emp);
  //   var headerOptions = new Headers({'Content-Type':'application/json'});
  //   var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
  //   return this.http.post('http://localhost:28750/api/Employee',body,requestOptions).map(x => x.json());
  // }
 
  // putEmployee(id, emp) {
  //   var body = JSON.stringify(emp);
  //   var headerOptions = new Headers({ 'Content-Type': 'application/json' });
  //   var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
  //   return this.http.put('http://localhost:28750/api/Employee/' + id,
  //     body,
  //     requestOptions).map(res => res.json());
  // }

  // deleteEmployee(id: number) {
  //   return this.http.delete('http://localhost:28750/api/Employee/' + id).map(res => res.json());
  // }

}
