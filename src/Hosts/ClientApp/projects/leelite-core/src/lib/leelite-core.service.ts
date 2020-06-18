import { Injectable } from '@angular/core';
import { SidebarConfig } from './configs/sidebar-config';

@Injectable({
  providedIn: 'root'
})
export class LeeliteCoreService {
  public Sidebar: SidebarConfig = new SidebarConfig();

  constructor() { }
}
