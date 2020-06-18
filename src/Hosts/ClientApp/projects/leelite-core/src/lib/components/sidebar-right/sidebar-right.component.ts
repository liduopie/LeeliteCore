import { Component, OnInit, HostBinding } from '@angular/core';
import { LeeliteCoreService } from 'leelite-core/leelite-core.service';

@Component({
  selector: 'leelite-sidebar-right',
  templateUrl: './sidebar-right.component.html',
  styleUrls: ['./sidebar-right.component.scss'],
  host: {
    'class': 'sidebar sidebar-light sidebar-right sidebar-expand-md'
  }
})
export class SidebarRightComponent implements OnInit {
  
  @HostBinding('class.sidebar-fullscreen')
  fullscreenClass = false;

  constructor(private coreService: LeeliteCoreService) { 
    this.coreService.Sidebar.MobileRightFullscreenState.subscribe(state => {
      this.fullscreenClass = state;
    });
  }

  ngOnInit() {
  }

  onToggleClick() {
    this.coreService.Sidebar.MobileRightToggle();
  }

  onFullscreenClick() {
    this.coreService.Sidebar.MobileRightFullscreenToggle();
  }
}
