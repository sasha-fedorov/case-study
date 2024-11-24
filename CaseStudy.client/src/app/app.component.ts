import { Component, OnInit } from '@angular/core';
import { Book } from '../shared/models/Book';
import { BookListComponent } from './book-list/book-list.component';
import { BooksHeaderComponent } from './books-header/books-header.component';
import { Collection } from '../shared/models/Collection';
import { CollectionsHeaderComponent } from './collections-header/collections-header.component';
import { CollectionListComponent } from './collection-list/collection-list.component';
import { BookService } from './book.service';
import { CollectionService } from './collection.service';
import { EventService } from './../shared/services/EventService';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    BookListComponent,
    BooksHeaderComponent,
    CollectionsHeaderComponent,
    CollectionListComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  books: Book[] = [];
  bookGenres: String[] = [];
  collections: Collection[] = [];

  constructor(
    events: EventService,
    private readonly bookService: BookService,
    private readonly collectionService: CollectionService
  ) {
    events.listen('addBook', (book: Book) => {
      this.bookService.addBook(book).subscribe(() => {
        this.updateData();
      });
    });

    events.listen('editBook', (book: Book) => {
      this.bookService.updateBook(book).subscribe(() => {
        this.updateData();
      });
    });

    events.listen('deleteBook', (book: Book) => {
      this.bookService.deleteBook(book).subscribe(() => {
        this.updateData();
      });
    });

    events.listen('addCollection', (collection: Collection) => {
      this.collectionService.addCollection(collection).subscribe(() => {
        this.updateData();
      });
    });

    events.listen('updateCollection', (collection: Collection) => {
      this.collectionService.updateCollection(collection).subscribe(() => {
        this.updateData();
      });
    });

    events.listen('deleteCollection', (collection: Collection) => {
      this.collectionService.deleteCollection(collection).subscribe(() => {
        this.updateData();
      });
    });
  }

  ngOnInit(): void {
    this.getBookGenres();
    this.updateData();
  }

  updateData() {
    this.getBooks();
    this.getCollections();
  }

  getBooks() {
    this.bookService.getBooks().subscribe((books) => {
      this.books = books;
    });
  }

  getBookGenres() {
    this.bookService.getBookGenres().subscribe((geners) => {
      this.bookGenres = geners;
    });
  }

  getCollections() {
    this.collectionService.getCollections().subscribe((collections) => {
      this.collections = collections;
    });
  }
}
