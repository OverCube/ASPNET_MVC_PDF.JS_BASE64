        // GET:
        public ActionResult PDFjs(string id)
        {
            if (!Request.IsAuthenticated || Session["UserNo"] == null) {
                return RedirectToAction("LoginStaff", "Account");
            }

            if (id == null) {
                return RedirectToAction("Menu", "Staff");  //パラメータ無しはメニューに移動
            }

            //pdffileをbase64へ変更
            string vPdf = ConfigurationManager.AppSettings["PDFUri"].ToString()
                + Session["UserNo"].ToString() + "_" + id + ".pdf";
            ViewBag.Base64 = GetBase64(vPdf);

            return View();
        }
