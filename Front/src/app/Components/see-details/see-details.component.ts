import { AfterViewInit, Component, ElementRef, Input, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as bootstrap from 'bootstrap';
import { ServicesBooksService } from 'src/app/Services/services-books.service';

@Component({
  selector: 'app-see-details',
  templateUrl: './see-details.component.html',
  styleUrls: ['./see-details.component.css']
})
export class SeeDetailsComponent  implements AfterViewInit {

  id:any;
  details:any = null;

  constructor(private route: ActivatedRoute,private serviceBooks: ServicesBooksService){}
  
  ngOnInit(){
  }

  public openModal(id:any){
    console.log(id);
    this.id = id;
    this.serviceBooks.GetDetailBook(id).subscribe((res:any) => {
      this.details = res.data;
      console.log(res.data);
      const modalElement = document.getElementById('exampleModalToggle');
      if (modalElement) {
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
      };
    });
    
  }

  ngAfterViewInit(): void {
  }
}
