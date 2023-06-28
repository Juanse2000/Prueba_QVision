import { AfterViewInit, Component, EventEmitter, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import * as bootstrap from 'bootstrap';
import { ServicesBooksService } from 'src/app/Services/services-books.service';
import { Router } from '@angular/router';
import { ListBooksComponent } from '../list-books/list-books.component';

@Component({
  selector: 'app-update-books',
  templateUrl: './update-books.component.html',
  styleUrls: ['./update-books.component.css']
})
export class UpdateBooksComponent implements AfterViewInit {

  @ViewChild(ListBooksComponent) listBooksComponent: ListBooksComponent | undefined;

  id:any;
  details:any = null;

  bookUpdate: {
    IdLibro: any;
    Titulo: string;
    NPaginas: string;
    Sinopsis: string
  } = {
    IdLibro: null,
    Titulo: '',
    NPaginas: '',
    Sinopsis: ''
  };

  modalClosed: EventEmitter<void> = new EventEmitter<void>();

  constructor(private route: ActivatedRoute,private serviceBooks: ServicesBooksService, private router: Router){}

  ngOnInit(){
  }

  public modalUpdateBooks(id:any){
    console.log('Llega aca');
    this.id = id;
    this.serviceBooks.GetBookById(id).subscribe((res:any) => {
      this.details = res.data;
      this.bookUpdate.IdLibro = this.details.idLibro;
      this.bookUpdate.Titulo = this.details.nombreLibro;
      this.bookUpdate.NPaginas  = this.details.paginas ;
      this.bookUpdate.Sinopsis  = this.details.sinopsis ;
      console.log(res.data);
      const modalElement = document.getElementById('ModalUpdate');
      if (modalElement) {
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
      };
    });
    
  }

  sendDataBookUpdate(form: NgForm){
    if (form.valid) {
      console.log(this.bookUpdate);
      this.serviceBooks.UpdateBook(this.bookUpdate).subscribe((res: any) => {
        console.log(res);
        console.log(this.listBooksComponent);
      })
    }
  }

  ngAfterViewInit(): void {
  }
}
