import { Injectable } from '@angular/core';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ServicesBooksService {

  constructor(private http: HttpClient) { }

  GetBooks(){
    return this.http.get('https://localhost:44368/api/Libreria/ObtenerLibros');
  }

  GetDetailBook(id:any){
    return this.http.get('https://localhost:44368/api/Libreria/ObtenerDetalle/' + id);
  }

  GetListEditorial(){
    return this.http.get('https://localhost:44368/api/Libreria/ObtenerListaEditoriales');
  } 

  GetListAutor(){
    return this.http.get('https://localhost:44368/api/Libreria/ObtenerListaAutores');
  }

  AddNewBook(dataBook: any){
    return this.http.post('https://localhost:44368/api/Libreria/AgregarLibro', dataBook)
  }

  GetBookById(id:any){
    return this.http.get('https://localhost:44368/api/Libreria/ObtenerLibroPorId/' + id)
  }

  UpdateBook(dataBook: any){
    return this.http.put('https://localhost:44368/api/Libreria/ActualizarLibro/' + dataBook.IdLibro, dataBook)
  }
}
