﻿namespace sistemaGerencia.Models
{
    public class PermissaoModel
    {
        public int IdPermissao { get; set; }
        public string? NomePermissão { get; set; }
        public string? DescricaoPermissao { get; set; }
        public ICollection<GrupoModel> grupos { get; set; }
    }
}