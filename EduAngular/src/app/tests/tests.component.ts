import { Component, OnInit } from '@angular/core';
import { TestService } from '../shared/test.service';

@Component({
  selector: 'app-tests',
  templateUrl: './tests.component.html',
  styleUrls: ['./tests.component.css']
})
export class TestsComponent implements OnInit {

  constructor(private testService : TestService) {  }

  ngOnInit() {
    this.testService.getTestList();
  }

}
