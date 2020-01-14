import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-upperbar',
  templateUrl: './upperbar.component.html',
  styleUrls: ['./upperbar.component.css']
})
export class UpperbarComponent implements OnInit {
  userName : any;
  userClaims : any;
  constructor(private router: Router, private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaims().subscribe((data: any) => {
      this.userClaims = data;
    });
  }

  Logout() {
    localStorage.removeItem('userToken');
    localStorage.removeItem('userRoles');
    localStorage.removeItem('userName');
    this.router.navigate(['/login']);
  }
}
