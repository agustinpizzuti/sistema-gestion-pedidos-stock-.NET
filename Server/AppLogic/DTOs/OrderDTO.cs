using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogic.MapperDTO;

namespace AppLogic.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public int idClient { get; set; }
        public ClientDTO client { get; set; }
        public List<LineDTO> lines { get; set; }
        public double finalPrice { get; set; }
        public bool cancel { get; set; }
        public bool delivered { get; set; }
        public bool isExrpress { get; set; }

        public OrderDTO() { }

        public OrderDTO(Order order)
        {
            if (order != null) 
            {
                this.Id = order.Id;
                this.creationDate = order.creationDate;
                this.deliveryDate = order.deliveryDate;
                this.idClient = order.idClient;
                this.client = ClientDTOMapper.ToDto(order.client);
                this.lines =order.lines.Select(line => LineDTOMapper.ToDto(line)).ToList();
                this.finalPrice = order.finalPrice;
                this.cancel = order.cancel;
                this.delivered = order.delivered;
                this.isExrpress = order.isExrpress;
            }

        }
    }
}
