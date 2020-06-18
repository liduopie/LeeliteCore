import { Component, OnInit, HostBinding, Inject } from '@angular/core';

import { AuthorizeService } from './authorization/authorize/authorize.service';
import { LeeliteCoreService } from 'leelite-core';

@Component({
  selector: 'body',
  templateUrl: './leelite-app.component.html',
  styleUrls: ['./leelite-app.component.scss'],
  host: {
    'class': 'navbar-top'
  }
})
export class LeeliteAppComponent implements OnInit {

  @HostBinding('class.sidebar-xs')
  sidebarMainClosedClass = false;

  @HostBinding('class.sidebar-secondary-hidden')
  sidebarSecondaryClosedClass = false;

  @HostBinding('class.sidebar-right-visible')
  sidebarRightOpenedClass = false;

  @HostBinding('class.sidebar-mobile-main')
  mobileMainOpenedClass = false;

  @HostBinding('class.sidebar-mobile-secondary')
  mobileSecondaryOpenedClass = false;

  @HostBinding('class.sidebar-mobile-right')
  mobileRightOpenedClass = false;

  constructor(private authorizeService: AuthorizeService, private coreService: LeeliteCoreService, @Inject(AuthorizeService) aa: AuthorizeService) {
    this.coreService.Sidebar.MainState.subscribe(state => {
      this.sidebarMainClosedClass = !state;
    });

    this.coreService.Sidebar.SecondaryState.subscribe(state => {
      this.sidebarSecondaryClosedClass = !state;
    });

    this.coreService.Sidebar.RightState.subscribe(state => {
      this.sidebarRightOpenedClass = state;
    });

    this.coreService.Sidebar.MobileMainState.subscribe(state => {
      this.mobileMainOpenedClass = state;
    });

    this.coreService.Sidebar.MobileSecondaryState.subscribe(state => {
      this.mobileSecondaryOpenedClass = state;
    });

    this.coreService.Sidebar.MobileRightState.subscribe(state => {
      this.mobileRightOpenedClass = state;
    });
  };

  async ngOnInit() {
  }

}
