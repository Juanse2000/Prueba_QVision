import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesBooksService } from 'src/app/Services/services-books.service';
import { SeeDetailsComponent } from '../see-details/see-details.component';
import { UpdateBooksComponent } from '../update-books/update-books.component';

@Component({
  selector: 'app-list-books',
  templateUrl: './list-books.component.html',
  styleUrls: ['./list-books.component.css']
})
export class ListBooksComponent {

  @ViewChild(SeeDetailsComponent) seeDetailsComponent: SeeDetailsComponent | undefined;
  @ViewChild(UpdateBooksComponent) updateBooksComponent: UpdateBooksComponent | undefined;

  
  listBooks: any[] = [];
  idBook:any;
  constructor(private serviceBooks: ServicesBooksService,private router: Router){

  }

  ngOnInit() {
    this.serviceBooks.GetBooks().subscribe((res:any) => {
      this.listBooks = res.data;
    });
  }

  seeDetails(id:any){
    this.idBook = id;
    this.seeDetailsComponent?.openModal(id);
  }

  updateBooks(id:any){
    this.idBook = id;
    this.updateBooksComponent?.modalUpdateBooks(id);
  }
}
