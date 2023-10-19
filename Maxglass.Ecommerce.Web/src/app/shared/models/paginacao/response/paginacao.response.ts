export class PaginacaoResponse<T> {
    quantidade: number;
    registros: Array<T>;

    constructor(params: Partial<PaginacaoResponse<T>>) {
        this.quantidade = params.quantidade || 0;
        this.registros = params.registros || [];
    }
}
