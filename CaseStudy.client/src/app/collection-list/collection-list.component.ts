import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Collection } from '../../shared/models/Collection';
import { CollectionItemComponent } from '../collection-item/collection-item.component';

@Component({
  selector: 'collection-list',
  standalone: true,
  imports: [CommonModule, CollectionItemComponent],
  templateUrl: './collection-list.component.html',
  styleUrl: './collection-list.component.css',
})
export class CollectionListComponent {
  @Input() collections: Collection[] = [];
}
