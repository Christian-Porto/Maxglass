export class ClientePessoaJuridicaResponse {
  email: string;
  cep: string;
  cnpj: string;
  razaoSocial: string;
  inscricaoEstadual : string;
  nomeFantasia : string;


  constructor(params: Partial<ClientePessoaJuridicaResponse>) {
      this.email = params.email || null;
      this.cep = params.cep || null;
      this.cnpj = params.cnpj || null;
      this.razaoSocial = params.razaoSocial || null;
      this.inscricaoEstadual = params.inscricaoEstadual || null;
      this.nomeFantasia = params.nomeFantasia || null;
  }
}
