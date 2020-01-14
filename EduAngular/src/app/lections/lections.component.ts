import { Component, OnInit } from '@angular/core';
import { LectionService } from '../shared/lection.service';

@Component({
  selector: 'app-lections',
  templateUrl: './lections.component.html',
  styleUrls: ['./lections.component.css']
})
export class LectionsComponent implements OnInit {

  constructor(private lectionService : LectionService) {  }

  ngOnInit() {
    this.lectionService.getLectionList();
  }

}
