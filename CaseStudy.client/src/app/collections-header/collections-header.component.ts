import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CollectionFormComponent } from '../collection-form/collection-form.component';

@Component({
  selector: 'collections-header',
  standalone: true,
  imports: [CollectionFormComponent, CommonModule],
  templateUrl: './collections-header.component.html',
  styleUrl: './collections-header.component.css',
})
export class CollectionsHeaderComponent {
  isAdding: boolean = false;

  onToggle() {
    this.isAdding = !this.isAdding;
  }
}
