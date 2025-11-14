Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class dailyreportform
    Private ReadOnly connectionString As String =
        "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"

    Private chartProd As Chart
    Private chartSvc As Chart
    Private chartHotel As Chart
    Private chartOverall As Chart

    Private Sub dailyreportform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateChartsInPanels()
        LoadAllData()
    End Sub

    Private Sub refbttn_Click(sender As Object, e As EventArgs)
        LoadAllData()
    End Sub

    ' ---------------- CREATE CHARTS INSIDE PANELS ----------------
    Private Sub CreateChartsInPanels()
        prodchartpanel.Controls.Clear()
        servchartpanel.Controls.Clear()
        hotelchartpanel.Controls.Clear()
        overallchartpanel.Controls.Clear()

        chartProd = CreateChart("Products", Color.FromArgb(72, 133, 237))
        chartSvc = CreateChart("Grooming", Color.FromArgb(67, 160, 71))
        chartHotel = CreateChart("Hotel", Color.FromArgb(244, 180, 0))

        ' Create overall chart with 3 colored series
        chartOverall = New Chart() With {
        .BackColor = Color.WhiteSmoke,
        .BorderlineColor = Color.Gray,
        .BorderlineDashStyle = ChartDashStyle.Solid,
        .BorderlineWidth = 1
    }

        Dim area As New ChartArea("MainArea")
        area.AxisX.MajorGrid.Enabled = False
        area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        area.AxisY.Title = "₱ Sales"
        area.AxisX.Interval = 1
        area.AxisX.LabelStyle.Angle = -45
        area.AxisX.LabelStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        chartOverall.ChartAreas.Add(area)
        chartOverall.Titles.Add("Overall Sales (Last 7 Days)")

        Dim legend As New Legend("MainLegend") With {
    .Docking = Docking.Top,
    .Alignment = StringAlignment.Center,
    .Font = New Font("Segoe UI", 9, FontStyle.Bold)
}
        chartOverall.Legends.Add(legend)

        ' Each category different color
        Dim prodSeries As New Series("Products") With {
        .ChartType = SeriesChartType.Column,
        .Color = Color.FromArgb(72, 133, 237),
        .BorderWidth = 2,
        .IsValueShownAsLabel = True
    }

        Dim svcSeries As New Series("Grooming") With {
        .ChartType = SeriesChartType.Column,
        .Color = Color.FromArgb(67, 160, 71),
        .BorderWidth = 2,
        .IsValueShownAsLabel = True
    }

        Dim hotelSeries As New Series("Hotel") With {
        .ChartType = SeriesChartType.Column,
        .Color = Color.FromArgb(244, 180, 0),
        .BorderWidth = 2,
        .IsValueShownAsLabel = True
    }

        chartOverall.Series.Add(prodSeries)
        chartOverall.Series.Add(svcSeries)
        chartOverall.Series.Add(hotelSeries)

        chartProd.Dock = DockStyle.Fill
        chartSvc.Dock = DockStyle.Fill
        chartHotel.Dock = DockStyle.Fill
        chartOverall.Dock = DockStyle.Fill

        prodchartpanel.Controls.Add(chartProd)
        servchartpanel.Controls.Add(chartSvc)
        hotelchartpanel.Controls.Add(chartHotel)
        overallchartpanel.Controls.Add(chartOverall)
    End Sub


    Private Function CreateChart(title As String, color As Color) As Chart
        Dim ch As New Chart() With {
            .BackColor = Color.WhiteSmoke,
            .BorderlineColor = Color.Gray,
            .BorderlineDashStyle = ChartDashStyle.Solid,
            .BorderlineWidth = 1
        }

        Dim area As New ChartArea("MainArea")
        area.AxisX.MajorGrid.Enabled = False
        area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        area.AxisY.Title = "₱ Sales"
        area.AxisX.Interval = 1
        area.AxisX.LabelStyle.Angle = -45
        area.AxisX.LabelStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        ch.ChartAreas.Add(area)

        Dim colSeries As New Series($"{title} (Bar)") With {
            .ChartType = SeriesChartType.Column,
            .Color = color,
            .BorderWidth = 2,
            .IsValueShownAsLabel = True
        }

        Dim lineSeries As New Series($"{title} (Line)") With {
            .ChartType = SeriesChartType.Line,
            .BorderWidth = 3,
            .Color = Color.FromArgb(200, 33, 33, 33),
            .MarkerStyle = MarkerStyle.Circle,
            .MarkerSize = 7,
            .IsValueShownAsLabel = False
        }

        ch.Series.Add(colSeries)
        ch.Series.Add(lineSeries)
        ch.Titles.Add($"{title} - Last 7 Days")

        Return ch
    End Function

    ' ---------------- MAIN LOAD FUNCTION ----------------
    Private Sub LoadAllData()
        Dim prodTotals = LoadProductSales()
        Dim svcTotals = LoadServiceSales()
        Dim hotelTotals = LoadHotelSales()
        LoadOverallSales(prodTotals, svcTotals, hotelTotals)
    End Sub

    ' ---------------- PRODUCTS ----------------
    Private Function LoadProductSales() As Dictionary(Of String, Decimal)
        Dim totals As New Dictionary(Of String, Decimal)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim qToday As String = "
                    SELECT bp.DetailID, pt.ProductName, bp.Quantity, bp.Price, bp.LineTotal, b.PaymentMethod, b.BillDate
                    FROM BillingProducts bp
                    JOIN BillingTable b ON bp.BillID = b.BillID
                    LEFT JOIN ProductTable pt ON bp.ProductID = pt.ProductID
                    WHERE CAST(b.BillDate AS DATE) = CAST(GETDATE() AS DATE)
                    ORDER BY b.BillDate DESC"
                Dim da As New SqlDataAdapter(qToday, con)
                Dim dt As New DataTable()
                da.Fill(dt)
                proddg.DataSource = dt

                Dim q7Days As String = "
                    SELECT CAST(b.BillDate AS DATE) AS [Date], SUM(bp.LineTotal) AS TotalSales
                    FROM BillingProducts bp
                    JOIN BillingTable b ON bp.BillID = b.BillID
                    WHERE b.BillDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
                    GROUP BY CAST(b.BillDate AS DATE)
                    ORDER BY [Date]"
                Dim cmd As New SqlCommand(q7Days, con)
                Dim rdr = cmd.ExecuteReader()
                While rdr.Read()
                    totals(Convert.ToDateTime(rdr("Date")).ToString("MM/dd")) = Convert.ToDecimal(rdr("TotalSales"))
                End While
                rdr.Close()

                chartProd.Series(0).Points.Clear()
                chartProd.Series(1).Points.Clear()
                For Each kv In totals
                    chartProd.Series(0).Points.AddXY(kv.Key, kv.Value)
                    chartProd.Series(1).Points.AddXY(kv.Key, kv.Value)
                Next

                Dim totalToday As Decimal = If(totals.ContainsKey(Date.Now.ToString("MM/dd")), totals(Date.Now.ToString("MM/dd")), 0)
                prodtotallbl.Text = $"Products Total (Today): ₱{totalToday:N2}"
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load product sales: " & ex.Message)
        End Try
        Return totals
    End Function

    ' ---------------- SERVICES ----------------
    Private Function LoadServiceSales() As Dictionary(Of String, Decimal)
        Dim totals As New Dictionary(Of String, Decimal)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim qToday As String = "
                    SELECT b.BillID, b.AppointmentID, b.TotalAmount, b.PaymentMethod, b.BillDate
                    FROM BillingTable b
                    WHERE CAST(b.BillDate AS DATE) = CAST(GETDATE() AS DATE)
                      AND b.AppointmentID IS NOT NULL
                    ORDER BY b.BillDate DESC"
                Dim da As New SqlDataAdapter(qToday, con)
                Dim dt As New DataTable()
                da.Fill(dt)
                servdg.DataSource = dt

                Dim q7Days As String = "
                    SELECT CAST(b.BillDate AS DATE) AS [Date], SUM(b.TotalAmount) AS TotalSales
                    FROM BillingTable b
                    WHERE b.BillDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
                      AND b.AppointmentID IS NOT NULL
                    GROUP BY CAST(b.BillDate AS DATE)
                    ORDER BY [Date]"
                Dim cmd As New SqlCommand(q7Days, con)
                Dim rdr = cmd.ExecuteReader()
                While rdr.Read()
                    totals(Convert.ToDateTime(rdr("Date")).ToString("MM/dd")) = Convert.ToDecimal(rdr("TotalSales"))
                End While
                rdr.Close()

                chartSvc.Series(0).Points.Clear()
                chartSvc.Series(1).Points.Clear()
                For Each kv In totals
                    chartSvc.Series(0).Points.AddXY(kv.Key, kv.Value)
                    chartSvc.Series(1).Points.AddXY(kv.Key, kv.Value)
                Next

                Dim totalToday As Decimal = If(totals.ContainsKey(Date.Now.ToString("MM/dd")), totals(Date.Now.ToString("MM/dd")), 0)
                servtotallbl.Text = $"Grooming Total (Today): ₱{totalToday:N2}"
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load service sales: " & ex.Message)
        End Try
        Return totals
    End Function

    ' ---------------- HOTEL ----------------
    Private Function LoadHotelSales() As Dictionary(Of String, Decimal)
        Dim totals As New Dictionary(Of String, Decimal)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim qToday As String = "
                    SELECT b.BillID, b.BookingID, b.TotalAmount, b.PaymentMethod, b.BillDate
                    FROM BillingTable b
                    WHERE CAST(b.BillDate AS DATE) = CAST(GETDATE() AS DATE)
                      AND b.BookingID IS NOT NULL
                    ORDER BY b.BillDate DESC"
                Dim da As New SqlDataAdapter(qToday, con)
                Dim dt As New DataTable()
                da.Fill(dt)
                hoteldg.DataSource = dt

                Dim q7Days As String = "
                    SELECT CAST(b.BillDate AS DATE) AS [Date], SUM(b.TotalAmount) AS TotalSales
                    FROM BillingTable b
                    WHERE b.BillDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
                      AND b.BookingID IS NOT NULL
                    GROUP BY CAST(b.BillDate AS DATE)
                    ORDER BY [Date]"
                Dim cmd As New SqlCommand(q7Days, con)
                Dim rdr = cmd.ExecuteReader()
                While rdr.Read()
                    totals(Convert.ToDateTime(rdr("Date")).ToString("MM/dd")) = Convert.ToDecimal(rdr("TotalSales"))
                End While
                rdr.Close()

                chartHotel.Series(0).Points.Clear()
                chartHotel.Series(1).Points.Clear()
                For Each kv In totals
                    chartHotel.Series(0).Points.AddXY(kv.Key, kv.Value)
                    chartHotel.Series(1).Points.AddXY(kv.Key, kv.Value)
                Next

                Dim totalToday As Decimal = If(totals.ContainsKey(Date.Now.ToString("MM/dd")), totals(Date.Now.ToString("MM/dd")), 0)
                hoteltotallbl.Text = $"Hotel Total (Today): ₱{totalToday:N2}"
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load hotel sales: " & ex.Message)
        End Try
        Return totals
    End Function

    ' ---------------- OVERALL SALES ----------------
    Private Sub LoadOverallSales(prod As Dictionary(Of String, Decimal),
                             svc As Dictionary(Of String, Decimal),
                             hotel As Dictionary(Of String, Decimal))
        chartOverall.Series("Products").Points.Clear()
        chartOverall.Series("Grooming").Points.Clear()
        chartOverall.Series("Hotel").Points.Clear()

        ' Gather all distinct dates
        Dim allDates = (prod.Keys.Concat(svc.Keys).Concat(hotel.Keys)).Distinct().OrderBy(Function(x) x).ToList()

        For Each d In allDates
            Dim p = If(prod.ContainsKey(d), prod(d), 0D)
            Dim s = If(svc.ContainsKey(d), svc(d), 0D)
            Dim h = If(hotel.ContainsKey(d), hotel(d), 0D)

            chartOverall.Series("Products").Points.AddXY(d, p)
            chartOverall.Series("Grooming").Points.AddXY(d, s)
            chartOverall.Series("Hotel").Points.AddXY(d, h)
        Next

        ' Total today (sum of all)
        Dim todayKey = Date.Now.ToString("MM/dd")
        Dim totalToday As Decimal = If(prod.ContainsKey(todayKey), prod(todayKey), 0) +
                                 If(svc.ContainsKey(todayKey), svc(todayKey), 0) +
                                 If(hotel.ContainsKey(todayKey), hotel(todayKey), 0)
        overalltotallbl.Text = $"Overall Total (Today): ₱{totalToday:N2}"
    End Sub

End Class
