import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './signin.component.html'
})
export class SignInComponent {
  public inLoading: boolean = false;
  public isError: boolean = false;
  public message: string = ""

  constructor(
    private fb: FormBuilder,
    private service: AuthService,
    private router: Router
    ) {
  }

  login = this.fb.group({
    acUser: ['', [Validators.required, Validators.minLength(5), Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$")]],
    acPassword: ['', [Validators.required, Validators.minLength(5)]]
  });

  get isValidUser(){ return this.login.get('acUser')?.invalid && this.login.get('acUser')?.touched;}

  get isValidPassword(){ return this.login.get('acPassword')?.invalid && this.login.get('acPassword')?.touched;}

  
  evtValidLogin(){
    if(this.login.invalid){
      return Object.values(this.login.controls).forEach(control => {
        control.markAllAsTouched();
      });
    }
    this.isError = false;
    this.inLoading = true;
    this.service.auth(this.login.value).subscribe({
      next: (response) => {
        this.inLoading = false;
        this.message = response.message;
        if(response.ok){
          localStorage.setItem("strToken", response.data.strToken);
          localStorage.setItem("strCode", response.data.strCode);
          localStorage.setItem("fullName", response.data.fullName);
          this.router.navigate(['/Main']);
        }else{
          this.isError = true;
        }
      },
      error: (error) => {
        this.inLoading = false;
        this.isError = true;
        this.message = "Ocurrió un error por favor inténtalo más tarde.";
      }
    })
  }
}