import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LeeliteCoreModule, LeeliteAppComponent, AuthorizeGuard } from 'leelite-core';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NavbarComponent,
    SidebarComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    LeeliteCoreModule,
    RouterModule.forRoot([
      {
        path: '',
        canActivate: [AuthorizeGuard],
        children: [
          { path: '', component: HomeComponent, pathMatch: 'full' },
          { path: 'counter', component: CounterComponent },
          { path: 'fetch-data', component: FetchDataComponent }
        ]
      },
      { path: '', component: NavbarComponent, outlet: 'navbar' },
      { path: '', component: FooterComponent, outlet: 'footer' },
      { path: '', component: SidebarComponent, outlet: 'sidebar-main' },
    ]),
    BrowserAnimationsModule
  ],
  bootstrap: [LeeliteAppComponent]
})
export class AppModule { }
