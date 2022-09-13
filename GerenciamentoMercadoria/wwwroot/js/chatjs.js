//import { months } from './utils.js'

//$(document).ready(function () {
//    const ctx = document.getElementById('myChart');

//    const skipped = (ctx, value) => ctx.p0.skip || ctx.p1.skip ? value : undefined;

//    let segment = {
//        borderColor: ctx => skipped(ctx, 'rgb(0,0,0,0.2)'),
//        borderDash: ctx => skipped(ctx, [3, 6])
//    }

//    let datasets = [];
//    datasets.segment = {};

//    let data = {
//        labels: months({count: 12}),
//        datasets: datasets
//    }

//    let url = "https://localhost:7258/Home/Datas";


//    $.get(url).done(function (data) {
//        for (let i = 0; i < data.length; i++) {
//            datasets[i] = data[i]
//            datasets[i].Add
//        }
//        for (let i = 0; i < datasets.length; i++) {
//            for (let j = 0; j < datasets[i].data.length; j++) {
//                if (datasets[i].data[j] == -1) {
//                    datasets[i].data[j] = NaN;
//                }
//            }
//            datasets[i].segment = segment;
//        }
//    })

//    console.log(data)

//    const config = {
//        type: 'line',
//        data,
//        options: {
//            tension: 0.4,
//            spanGaps: true,
//            fill: false,
//            interaction: {
//                intersect: false,
//                mode: 'index',
//            },
//            radius: 5,
//        }
//    }

//    const myChart = new Chart(
//        document.getElementById('myChart'),
//        config
//    );
//})