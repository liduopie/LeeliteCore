import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'leelite-page-content',
  templateUrl: './page-content.component.html',
  styleUrls: ['./page-content.component.scss'],
  host: {
    'class': 'page-content'
  }
})
export class PageContentComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
