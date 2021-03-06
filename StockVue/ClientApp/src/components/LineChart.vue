﻿<!-- Template Tag can not be merged

    Do not include the <template> tag in your .vue single-file components.
    Vue can not merge templates. If you add an empty <template> tag,
    Vue will take the template from your component and not from the extended one,
    which will result in an empty template and unexpected errors.
-->
<script>
    import { Line } from 'vue-chartjs'

    export default {
        name: 'LineChart',
        extends: Line,
        props: {
            chartData: {
                type: Array | Object,
                required: false
            },
            chartLabels: {
                type: Array,
                required: true
            }
        },       
        data() {
            return {
                gradient: null,
                options: {
                    showScale: true,
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: false,
                                callback: (value, index, values) => {
                                    return this.formatNumber(value)
                                }
                            },
                            gridLines: {
                                display: true,
                                color: '#EEF0F4',
                                borderDash: [5, 15]
                            }
                        }],
                        xAxes: [{
                            gridLines: {
                                display: true,
                                color: '#EEF0F4',
                                borderDash: [5, 15]
                            }
                        }]
                    },
                    tooltips: {
                        backgroundColor: '#4F5565',
                        titleFontStyle: 'normal',
                        titleFontSize: 18,
                        bodyFontFamily: "'Proxima Nova', sans-serif",
                        cornerRadius: 3,
                        bodyFontColor: '#20C4C8',
                        bodyFontSize: 14,
                        xPadding: 14,
                        yPadding: 14,
                        displayColors: false,
                        mode: 'index',
                        intersect: false,
                        callbacks: {
                            title: tooltipItem => {
                                return `${tooltipItem[0].xLabel}`
                            },
                            label: (tooltipItem, data) => {
                                let dataset = data.datasets[tooltipItem.datasetIndex]
                                let currentValue = dataset.data[tooltipItem.index]
                                return ` ${currentValue.toLocaleString()}`
                            }
                        }
                    },
                    legend: {
                        display: false
                    },
                    responsive: true,
                    maintainAspectRatio: false
                }
            }
        },

        mounted() {
            this.renderChart({
                labels: this.chartLabels,
                datasets: [
                    {
                        label: 'Value',
                        borderColor: '#249EBF',
                        pointBackgroundColor: 'rgba(0,0,0,0)',
                        pointBorderColor: 'rgba(0,0,0,0)',
                        pointHoverBorderColor: '#249EBF',
                        pointHoverBackgroundColor: '#fff',
                        pointHoverRadius: 4,
                        pointHitRadius: 10,
                        pointHoverBorderWidth: 1,
                        borderWidth: 1,
                        data: this.chartData
                    }
                ]
            }, this.options)
        },
        methods: {
            formatNumber(num) {
                let numString = Math.round(num).toString()
                let numberFormatMapping = [[6, 'm'], [3, 'k']]
                for (let [numberOfDigits, replacement] of numberFormatMapping) {
                    if (numString.length > numberOfDigits) {
                        let decimal = ''
                        if (numString[numString.length - numberOfDigits] !== '0') {
                            decimal = '.' + numString[numString.length - numberOfDigits]
                        }
                        numString = numString.substr(0, numString.length - numberOfDigits) + decimal + replacement
                        break
                    }
                }
                return numString
            }
        }
    }
</script>

<style>
</style>