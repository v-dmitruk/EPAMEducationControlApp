import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {Response, Headers} from '@angular/http';
import {Observable} from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly rootUrl = 'http://localhost:52059/';
  constructor(private http : HttpClient) { }

registerUser(user : User){
  const body: User = {
    UserName: user.UserName,
    Password: user.Password,
    Email: user.Email,
    FirstName: user.FirstName,
    LastName: user.LastName,
    BirthdayDate: user.BirthdayDate,
    Role: user.Role
  }
  var reqHeader = new HttpHeaders({ 'No-Auth':'True' });
  return this.http.post(this.rootUrl + 'api/User/Register', body, {headers : reqHeader});
}

userAuthentication(userName, password) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth':'True' });
    return this.http.post(this.rootUrl + '/token', data, { headers: reqHeader });
  }

  getUserClaims(){
    return  this.http.get(this.rootUrl+'/api/GetUserClaims');
  }

   getAllRoles() {
  var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
  return this.http.get(this.rootUrl + '/api/GetAllRoles', { headers: reqHeader });
  }
  
  roleMatch(allowedRoles): boolean {
    var isMatch = false;
    var userRoles: string[] = JSON.parse(localStorage.getItem('userRoles'));
    allowedRoles.forEach(element => {
      if (userRoles.indexOf(element) > -1) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }

}
