﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Domain.Dtos
{
    public class SistemaResponseDTO : MensagemDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Versao { get; set; }
        public List<PerfilResponseDTO> PerfilDTO { get; set; }

    }
}

