import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HttpConfigInterceptor } from './helpers/httpconfig.interceptor';
import { AppServiceModule } from './app.services.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ComponentsModule } from './components/component.module';
import { AppRouterModule } from './app.router.module';
import { AppMainComponent } from './app.main.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
export function tokenGetter() {
  return localStorage.getItem("token");
}
@NgModule({
  declarations: [
    AppComponent,
    AppMainComponent,
    NavMenuComponent,
    LoginComponent,
  ],
  exports:[
  ],
  imports: [
    ComponentsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AppServiceModule,
    AppRouterModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
       tokenGetter: tokenGetter,
      },
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
