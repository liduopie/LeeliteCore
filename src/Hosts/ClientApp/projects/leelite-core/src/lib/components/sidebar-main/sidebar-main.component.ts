import { Component, OnInit, HostBinding } from '@angular/core';
import { LeeliteCoreService } from 'leelite-core/leelite-core.service';

@Component({
  selector: 'leelite-sidebar-main',
  templateUrl: './sidebar-main.component.html',
  styleUrls: ['./sidebar-main.component.scss'],
  host: {
    'class': 'sidebar sidebar-dark sidebar-main sidebar-expand-md'
  }
})
export class SidebarMainComponent implements OnInit {

  @HostBinding('class.sidebar-fullscreen')
  mobileFullscreenClass = false;

  constructor(private coreService: LeeliteCoreService) {
    this.coreService.Sidebar.MobileMainFullscreenState.subscribe(state => {
      this.mobileFullscreenClass = state;
    });
  }

  ngOnInit() {
  }

  onToggleClick() {
    this.coreService.Sidebar.MobileMainToggle();
  }

  onFullscreenClick() {
    this.coreService.Sidebar.MobileMainFullscreenToggle();
  }
}
