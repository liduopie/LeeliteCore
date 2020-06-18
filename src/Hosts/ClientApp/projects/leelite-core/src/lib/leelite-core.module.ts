import { NgModule, APP_INITIALIZER } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { BsDropdownModule } from 'ngx-bootstrap';

import { LeeliteAppRoutingModule } from './leelite-app-routing.module';
import { AuthorizationModule } from './authorization/authorization.module';
import { AuthorizeInterceptor } from './authorization/authorize/authorize.interceptor';
import { AuthorizeService } from './authorization/authorize/authorize.service';

import { NavbarComponent } from './components/navbar/navbar.component';
import { PageContentComponent } from './components/page-content/page-content.component';
import { SidebarMainComponent } from './components/sidebar-main/sidebar-main.component';
import { SidebarSecondaryComponent } from './components/sidebar-secondary/sidebar-secondary.component';
import { SidebarRightComponent } from './components/sidebar-right/sidebar-right.component';
import { FooterComponent } from './components/footer/footer.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { MainContentComponent } from './components/main-content/main-content.component';
import { LeeliteAppComponent } from './leelite-app.component';

const COMPONENTS = [
  NavbarComponent,
  PageContentComponent,
  SidebarMainComponent,
  SidebarSecondaryComponent,
  SidebarRightComponent,
  FooterComponent,
  PageHeaderComponent,
  MainContentComponent,
  LeeliteAppComponent
];

const initClientConfig = (service: AuthorizeService) => {
  return async () => {
    await service.ClientConfigInitialized();
  }
}
@NgModule({
  imports: [
    RouterModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    LeeliteAppRoutingModule,
    AuthorizationModule
  ],
  declarations: [...COMPONENTS],
  exports: [
    AuthorizationModule,
    ...COMPONENTS
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: APP_INITIALIZER, useFactory: initClientConfig, deps: [AuthorizeService], multi: true },
    { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
  ]
})
export class LeeliteCoreModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
