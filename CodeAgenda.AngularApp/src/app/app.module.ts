import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from "./Components/login/login.component";
import { LayoutComponent } from "./Components/layout/layout.component";
import { AppComponent } from "./app.component";

@NgModule({
    imports: [
        AppComponent,
        LoginComponent,
        LayoutComponent
    ]
})
export class AppModule { }
