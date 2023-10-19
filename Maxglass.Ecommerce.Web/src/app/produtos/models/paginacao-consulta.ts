export class PaginacaoConsulta<T> {
    quantidade: number;
    registros: Array<T>;

    constructor(params: Partial<PaginacaoConsulta<T>>) {
        this.quantidade = params.quantidade || null;
        this.registros = params.registros || null;
        
    }
}
