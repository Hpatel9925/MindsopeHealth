import { HttpClient } from '@angular/common/http';
import { Input } from '@angular/core';
import { Component, HostListener } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { SharedserviceService } from '../services/sharedservice.service';
import { NavMenuComponent} from '../nav-menu/nav-menu.component';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
 
  username!: any;
  password!: any;
  userExists!: boolean;
  alert!: boolean;
  
  loginForm: FormGroup;
  //@HostListener("window:onbeforeunload", ["$event"])
  //clearLocalStorage(event) {
  //  localStorage.clear();
  //}
  constructor(private service: SharedserviceService, private router: Router, private http: HttpClient)
  {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }

  login()
  {

    this.username = this.loginForm.get('username').value;
    this.password = this.loginForm.get('password').value;
   
    this.service.Login(this.username, this.password).subscribe((result: any) => {
      this.userExists = result;
      if (result)
      {
        this.service.isUser = true;
        this.service.isLoggedin = true;
        this.loginForm.reset();
        var RandomToken = Math.floor((Math.random() * 10000) + 1);
        sessionStorage.setItem("Token", JSON.stringify(RandomToken));
        this.router.navigate(['/database']);
      }
      else
      {
        this.alert = true;
      }
    });
  }

}
