﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Reflection.Emit;

public partial class YemekDetay : System.Web.UI.Page
{
    SqlConnect bgl = new SqlConnect();
    string yemekid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        yemekid = Request.QueryString["YemekId"];

        SqlCommand komut = new SqlCommand("Select YemekAd From Tbl_Yemekler where YemekId=@p1", bgl.baglanti());
        komut.Parameters.AddWithValue("@p1", yemekid);
        SqlDataReader dr = komut.ExecuteReader();
        while (dr.Read())
        {
            Label3.Text = dr[0].ToString();
        }
        bgl.baglanti().Close();

        //Yorumlar

        SqlCommand komut2 = new SqlCommand("Select * From Tbl_Yorumlar where YemekId=@p2", bgl.baglanti());
        komut2.Parameters.AddWithValue("@p2", yemekid);
        SqlDataReader dr2 = komut2.ExecuteReader();
        DataList2.DataSource = dr2;
        DataList2.DataBind();
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand komut3 = new SqlCommand("insert into Tbl_Yorumlar (yorumadsoyad,yorummail,yorumicerik,YemekId) values (@p3,@p4,@p5,@p6)", bgl.baglanti());
        komut3.Parameters.AddWithValue("@p3", TextBox1.Text);
        komut3.Parameters.AddWithValue("@p4", TextBox2.Text);
        komut3.Parameters.AddWithValue("@p5", TextBox3.Text);
        komut3.Parameters.AddWithValue("@p6", yemekid);
        komut3.ExecuteNonQuery();
        bgl.baglanti().Close();
    }
}