﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestePratico.Context;
using TestePratico.Models;
using TestePratico.Repository;

namespace TestePratico.Service
{
    public class VendaRealizadaService
    {
        private Modelo db = null;

        public List<Venda> BuscarVendasRealizadas()
        {
            if (db == null)
            {
                db = new Modelo();
            }

            List<Produto> produtos = null;
            List<Vendedor> vendedores = null;

            var vendas = db.Venda.ToList();

            if (vendas != null && vendas.Count > 0)
            {
                produtos = new ProdutoService().ListarProdutos();
                vendedores = new VendedorService().BuscarVendedores();
                /*
                foreach (var venda in vendas)
                {
                    venda.Produto = produtos.Where(p => p.cdProduto == venda.cdProduto).FirstOrDefault();
                    venda.Vendedor = vendedores.Where(v => v.cdVendedor == venda.cdVendedor).FirstOrDefault();
                }
                */
            }

            return vendas;
        }

        public List<Venda> BuscarVendas()
        {
            if (db == null)
            {
                db = new Modelo();
            }

            var vendas = db.Venda.ToList();

            return vendas;
        }

        public void DeletarVendaRealizada(Venda venda)
        {
            if (db == null)
            {
                db = new Modelo();
            }

            db.Venda.Attach(venda);
            db.Entry(venda).State = EntityState.Deleted;

            db.SaveChanges();
        }

        public void DeletarVendaRealizada(List<Produto> produtos)
        {
            if (db == null)
            {
                db = new Modelo();
            }

            var vendas = this.BuscarVendas();
            var listVendas = new List<Venda>();

            produtos.ForEach(produto => {
                var vds = vendas.Where(v => v.cdProduto == produto.cdProduto).ToList();

                if (vds != null)
                    listVendas.AddRange(vds);
            });

            if (listVendas != null && listVendas.Count > 0)
            {
                listVendas.ForEach(v =>
                {
                    db.Venda.Add(v);
                    db.Entry(v).State = EntityState.Deleted;
                    db.Venda.Remove(v);
                });
            }

            db.SaveChanges();
        }

        public void RealizarVenda(Venda venda)
        {
            if (db == null)
            {
                db = new Modelo();
            }

            var cdProduto = venda.cdProduto;
            var produto = db.Produto.Where(p => p.cdProduto == cdProduto).FirstOrDefault();

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            var cdVendedor = venda.cdVendedor;
            var vendedor = db.Vendedor.Where(v => v.cdVendedor == cdVendedor).FirstOrDefault();

            if (vendedor == null)
            {
                throw new Exception("Vendedor não encontrado");
            }

            var total = venda.qtdProduto * produto.vrProduto;
            venda.ttlVenda = total;

            db.Venda.Add(venda);
            db.SaveChanges();
        }
    }
}