import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  @HostListener("window:onunload", ["$event"])
  clearLocalStorage(event) {
    localStorage.removeItem('Token');
  }
}
