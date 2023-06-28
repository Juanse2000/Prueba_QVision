import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { ListBooksComponent } from './Components/list-books/list-books.component';
import { HttpClientModule } from '@angular/common/http';
import { SeeDetailsComponent } from './Components/see-details/see-details.component';
import { AddBooksComponent } from './Components/add-books/add-books.component';
import { UpdateBooksComponent } from './Components/update-books/update-books.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ListBooksComponent,
    SeeDetailsComponent,
    AddBooksComponent,
    UpdateBooksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
