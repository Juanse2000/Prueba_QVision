import { Component } from '@angular/core';
import { ServicesBooksService } from 'src/app/Services/services-books.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-books',
  templateUrl: './add-books.component.html',
  styleUrls: ['./add-books.component.css']
})
export class AddBooksComponent {

  listEditorial: any[] = [];
  listAutores: any[] = [];

  book: {
    infoBasica:{
      Titulo: string;
      Sinopsis: string;
      NPaginas: string;
      IdEditorial: any;
    },
    idAutor: any 
  } = {
    infoBasica:{
      Titulo: '',
      Sinopsis: '',
      NPaginas: '',
      IdEditorial: null,
    },
    idAutor: null
  };


  constructor(private serviceBooks: ServicesBooksService, private router: Router){

  }

  ngOnInit() {
    this.serviceBooks.GetListEditorial().subscribe((res:any) => {
      this.listEditorial = res.data;
      console.log(res);
    });
    this.serviceBooks.GetListAutor().subscribe((res:any) => {
      this.listAutores = res.data;
      console.log(res);
    });

  }

  sendDataBook(form: NgForm){
    if (form.valid) {
      console.log(this.book);
      this.serviceBooks.AddNewBook(this.book).subscribe((res: any) => {
        console.log(res);
        this.router.navigate(['/listBooks']);
      })
    }
  }
}
