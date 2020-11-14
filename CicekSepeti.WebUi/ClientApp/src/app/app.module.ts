import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HttpConfigInterceptor } from './helpers/httpconfig.interceptor';
import { AppServiceModule } from './app.services.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ComponentsModule } from './components/component.module';
import { AppRouterModule } from './app.router.module';
import { AppMainComponent } from './app.main.component';
@NgModule({
  declarations: [
    AppComponent,
    AppMainComponent,
    NavMenuComponent,
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
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
