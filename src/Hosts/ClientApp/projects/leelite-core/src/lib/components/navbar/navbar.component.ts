import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LeeliteCoreService } from 'leelite-core/leelite-core.service';
import { AuthorizeService } from 'leelite-core/authorization/authorize/authorize.service';

@Component({
  selector: 'leelite-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
  host: {
    'class': 'navbar navbar-expand-md navbar-light fixed-top'
  }
})
export class NavbarComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;

  constructor(private coreService: LeeliteCoreService, private authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }

  onSidebarMainToggleClick() {
    this.coreService.Sidebar.MainToggle();
  }

  onSidebarSecondaryToggleClick() {
    this.coreService.Sidebar.SecondaryToggle();
  }

  onSidebarRightToggleClick() {
    this.coreService.Sidebar.RightToggle();
  }

  onMobileMainToggleClick() {
    this.coreService.Sidebar.MobileMainToggle();
  }

  onMobileSecondaryToggleClick() {
    this.coreService.Sidebar.MobileSecondaryToggle();
  }

  onMobileRightToggleClick() {
    this.coreService.Sidebar.MobileRightToggle();
  }
}
