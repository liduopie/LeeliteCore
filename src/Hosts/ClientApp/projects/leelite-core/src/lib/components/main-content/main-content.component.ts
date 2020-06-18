import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'leelite-main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss'],
  host: {
    'class': 'content-wrapper'
  }
})
export class MainContentComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
