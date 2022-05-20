import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { SharedserviceService } from '../services/sharedservice.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
 
  constructor(private router: Router, private srv:SharedserviceService) {
    if (sessionStorage.getItem('Token') != null) {
      srv.isUser = true;
    }
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  Logout() {
    sessionStorage.removeItem('Token');
    this.srv.isUser = false;
    this.srv.isLoggedin = false;
    this.router.navigate(['/login']);
  }
}
