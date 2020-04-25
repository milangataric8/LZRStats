import { MatPaginatorIntl } from '@angular/material';
import { TranslateService } from '@ngx-translate/core';
import { Injectable } from '@angular/core';

@Injectable()
export class MatPaginatorI18nService extends MatPaginatorIntl {
    public constructor(private translate: TranslateService) {
        super();

        this.translate.onDefaultLangChange.subscribe((e: Event) => {
            this.getAndInitTranslations();
        });

        this.getAndInitTranslations();
    }

    public getRangeLabel = (page: number, pageSize: number, length: number): string => {
        if (length === 0 || pageSize === 0) {
            return `0 / ${length}`;
        }

        length = Math.max(length, 0);

        const startIndex: number = page * pageSize;
        const endIndex: number = startIndex < length
            ? Math.min(startIndex + pageSize, length)
            : startIndex + pageSize;

        return `${startIndex + 1} - ${endIndex} / ${length}`;
    }

    public getAndInitTranslations(): void {
        this.translate.get([
            'PAGINATOR.ITEMS_PER_PAGE',
            'PAGINATOR.NEXT_PAGE',
            'PAGINATOR.PREV_PAGE',
            'PAGINATOR.FIRST_PAGE',
            'PAGINATOR.LAST_PAGE',
        ])
            .subscribe((translation: any) => {
                this.itemsPerPageLabel = translation['PAGINATOR.ITEMS_PER_PAGE'];
                this.nextPageLabel = translation['PAGINATOR.NEXT_PAGE'];
                this.previousPageLabel = translation['PAGINATOR.PREV_PAGE'];
                this.firstPageLabel = translation['PAGINATOR.FIRST_PAGE'];
                this.lastPageLabel = translation['PAGINATOR.LAST_PAGE'];

                this.changes.next();
            });
    }
}
