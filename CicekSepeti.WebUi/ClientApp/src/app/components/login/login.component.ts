import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { IUserService } from 'src/app/services/abstract/serviceUser/UserService.service';
import { Globals } from 'src/app/helpers/global.helper';

@Component({templateUrl: 'login.component.html'})
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private userService: IUserService,
        private global: Globals
    ) {
        // redirect to home if already logged in
        if (this.global.hasValidToken()) { 
            console.log(this.global.hasValidToken());
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    // convenience getter for easy access to form fields
    get f() { return this.loginForm.controls; }

    onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }

        this.loading = true;
        var model: Users = {
            id:0,
            token:null,
            name:this.f.username.value,
            password: this.f.password.value
        };
        this.userService.login(model)
            .pipe(first())
            .subscribe(
                data => {
                    localStorage.setItem("token",data.token);
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    alert(error);
                    this.loading = false;
                });
    }
}
