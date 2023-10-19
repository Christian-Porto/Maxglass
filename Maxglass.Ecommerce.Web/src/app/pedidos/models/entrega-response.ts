export class FreteResponse {
    id: number;
    regiao: string;
    valor: number;
    
    constructor(params: Partial<FreteResponse>) {
        this.id = params.id || null;
        this.regiao = params.regiao || null;
        this.valor = params.valor || null;
    }
}
