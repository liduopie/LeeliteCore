import { Component, OnInit, HostBinding } from '@angular/core';
import { LeeliteCoreService } from 'leelite-core/leelite-core.service';

@Component({
  selector: 'leelite-sidebar-secondary',
  templateUrl: './sidebar-secondary.component.html',
  styleUrls: ['./sidebar-secondary.component.scss'],
  host: {
    'class': 'sidebar sidebar-light sidebar-secondary sidebar-expand-md'
  }
})
export class SidebarSecondaryComponent implements OnInit {

  @HostBinding('class.sidebar-fullscreen')
  mobileFullscreenClass = false;

  constructor(private coreService: LeeliteCoreService) {
    this.coreService.Sidebar.MobileSecondaryFullscreenState.subscribe(state => {
      this.mobileFullscreenClass = state;
    });
  }

  ngOnInit() {
  }

  onMobileSecondaryToggleClick() {
    this.coreService.Sidebar.MobileSecondaryToggle();
  }

  onMobileFullscreenClick() {
    this.coreService.Sidebar.MobileSecondaryFullscreenToggle();
  }
}
